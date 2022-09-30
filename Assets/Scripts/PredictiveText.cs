using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PredictiveText : MonoBehaviour
{

	public TextAsset testWords;

	private string[] testSet;	

	Trie.TrieNode root;

	
    // Start is called before the first frame update
    public void Start()
    {
		testSet = testWords.text.Split();
        root = new Trie.TrieNode();
		for (int i = 0; i < testSet.Length; i++) {
			Trie.insert(testSet[i], root);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Trie
{
	
	// Alphabet size (# of symbols)
	static readonly int ALPHABET_SIZE = 26;
	
	// trie node
	public class TrieNode
	{
		public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
	
		// isEndOfWord is true if the node represents
		// end of a word
		public bool isEndOfWord;
		
		public TrieNode()
		{
			isEndOfWord = false;
			for (int i = 0; i < ALPHABET_SIZE; i++)
				children[i] = null;
		}
	};
		
	// If not present, inserts key into trie
	// If the key is prefix of trie node,
	// just marks leaf node
	public static void insert(String key, TrieNode root)
	{
		int level;
		int length = key.Length;
		int index;
	
		TrieNode pCrawl = root;
	
		for (level = 0; level < length; level++)
		{
			if (char.IsLetter(key[level])) {
				index = char.ToLower(key[level]) - 'a';
				if (pCrawl.children[index] == null)
					pCrawl.children[index] = new TrieNode();
		
				pCrawl = pCrawl.children[index];
			}
		}
		// mark last node as leaf
		pCrawl.isEndOfWord = true;
	}
	
	// Returns true if key
	// presents in trie, else false
	static bool search(String key, TrieNode root)
	{
		int level;
		int length = key.Length;
		int index;
		TrieNode pCrawl = root;
	
		for (level = 0; level < length; level++)
		{
			index = key[level] - 'a';
	
			if (pCrawl.children[index] == null)
				return false;
	
			pCrawl = pCrawl.children[index];
		}
	
		return (pCrawl.isEndOfWord);
	}
}
