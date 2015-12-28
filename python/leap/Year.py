#checks if a year passed is a leap year
#all years diisible by 400 are leap years
#then all years divisible by 4 but not by 100 are also leap years


def is_leap_year(year):
    return year % 400 == 0 or (year % 4 == 0 and year % 100 != 0)