# File reader

Client needs a small and simple tool.  
UI should enable user to load a specified ANSI text file, filter words and count them.  
Program should return an array containing 2 columns (1st: a word;2nd: its count).  
Array content should be sorted by the word count (2nd column).  

Application must be responsive.  
High efficiency is desirable.  

User should be able to pick the desired file.  
Words in the file are separated with whitespaces.  
A progress bar must be available while processing large file.  

Specified content below...  

1: 1 Adam Seth Enos  
1: 2 Kainan Adam Seth Iared  

... should produce output as follows:

Word | Count
------------ | -------------
1:1  |  1
Adam |  2
Seth |  2
Enos |  1
1:2  |  1
Kainan| 1
Iared|  1

Sample file can be found in additionalfiles directory.
