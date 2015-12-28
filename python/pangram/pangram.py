#checks if a statement is a pangram
#uses a boolean array indexed by the alphabet
#for each character in the statement, that letter is set to true
#at the end, check if all values are set to true

def is_pangram(statement):
    letters = [False] * 26 #make a list of 26 (number of letters)
    for character in statement.lower():
        index = ord(character) - 97
        if index >= 0 and index <= 25: #catch for illegal values
            letters[index] = True #set that letter to true
    #extract the booleans that are false using a list comprehension
    #if there are any falses, return false
    if  not [boolean for boolean in letters if boolean == False]:
        return True
    return False

