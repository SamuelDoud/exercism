from collections import OrderedDict


def is_pangram(statement):
    #iterate through the lower case string and place letters into list_letters
    list_letters = [char for char in statement.lower() if is_lower(ord(char))]
    #removes duplicates from list by converting to dictionary and back to list
    list_letters_removed_duplicates = list(OrderedDict.fromkeys(list_letters))
    #checks if the list has all the letters in it and returns that result
    return (len(list_letters_removed_duplicates) == 26)


def is_lower(ASCII_value):
    #return if the ASCII_value is in the range of a lowerr
    return (ASCII_value >= 97 and ASCII_value <= (97 + 25))