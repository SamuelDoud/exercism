def to_rna(dna):
    #dictionary that defines the conversions between DNA and RNA
    nucleotides = {'G':'C', 'C':'G', 'T':'A', 'A':'U'}
    #list comp to take each char from dna and index with the dictionary
    return "".join([nucleotides[x] for x in dna])