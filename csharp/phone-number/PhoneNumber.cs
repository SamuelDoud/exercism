using System;
using System.Linq;
using System.Text.RegularExpressions;

class PhoneNumber
{
    public string Number {get; private set;}
    public string AreaCode { get; private set; }
    private string _phoneNumber;
    private string _formatedPhoneNumber;
    public readonly string USCode = "1";
    public readonly int correctLengthOfAPhoneNumber = 10;
    private readonly string emptyPhoneNumber = "0000000000";
    public PhoneNumber(string phoneNumber)
    {
        this._phoneNumber = phoneNumber;
        this._formatedPhoneNumber = "";
        Sanitize();
        SetAreaCode();
    }
    private void Sanitize()
    {
        string pattern = @"[\D]";//all non decimals
        Number = Regex.Replace(_phoneNumber, pattern, "");
        if (IsWrongLength() && Number.StartsWith(USCode)) //checks if the phone number is not the right length and then sees if it starts with a US code
        {//if the number doesn't actually have a US code, that doesn't matter as the length will still be wrong for the check below
           Number = Number.Substring(1, Number.Length - 1);//removes the first character
        }
        if (IsWrongLength())
        {
            Number = emptyPhoneNumber;//since this phone number is of the wrong length, we must make it clearly invalid
        }
    }
    private void SetAreaCode()
    {
        AreaCode = _phoneNumber.Substring(0, 3); //area codes are the first three digits in a 10-digit phone number
    }
    private bool IsWrongLength()
    {
        return Number.Length != correctLengthOfAPhoneNumber; //check if the phone number is of the standard length
    }
    public override string ToString()
    {
        if (_formatedPhoneNumber.Length == 0) //true if this has not been set yet
        {
            _formatedPhoneNumber = Regex.Replace(_phoneNumber, "\\b(?<AreaCode>\\d{3})(?<GroupCode>\\d{3})(?<PersonalCode>\\d{4})\\b", "(${AreaCode}) ${GroupCode}-${PersonalCode}");//format in the form of (###) ###-####
        }
        return _formatedPhoneNumber;
    }
}
