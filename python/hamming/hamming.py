def distance(base_strand, compare_strand):
    count = 0
    for base_char in range(0, len(base_strand)):
        count = count + (base_strand[base_char] is not compare_strand[base_char])
        #adds one to count if the characters are not equal
    return count