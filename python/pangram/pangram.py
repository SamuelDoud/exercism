from string import ascii_lowercase


def is_pangram(statement):
    return all(letter in statement.lower for letter in ascii_lowercase)
    #takes every letter in the lower case and checks for its existence
    #in the statement, if ALL letters are satisfied, return true