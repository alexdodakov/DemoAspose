T9 Spelling
The Latin alphabet contains 26 characters and telephones only have ten digits on the keypad. We would like to make it easier 
to write a message to your friend using a sequence of keypresses to indicate the desired characters. The letters are mapped 
onto the digits as shown below. To insert the character ‘B’ for instance, the program would press “22”. In order to insert 
two characters in sequence from the same key, the user must pause before pressing the key a second time. The space 
character ‘ ’ should be printed to indicate a pause. For example, “2 2” indicates “AA” whereas “22” indicates “B”.


Input and output data must be contained line by line in the corresponding text files.
Input
The first line of input gives the number of cases, N, 1 <= N <= 100. N test cases follow. 
Each case is a line of text containing the desired message, which will be at most 1000 
characters long. Each message will consist of only lowercase characters ‘a’–‘z’ and space
characters ‘ ’. Pressing zero emits a space.
Output
For each test case, output one line containing “Case #x: ” followed by the message 
translated into the sequence of key presses.
Sample Input 


4
hi
yes
foo  bar
hello world

Sample Output

 
Case #1: 44 444
Case #2: 999337777
Case #3: 333666 6660 022 2777
Case #4: 4433555 555666096667775553

