using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApi.Business
{
    public class Parser
    {
        public String Convert(String str)
        {
            try
            {
                //I decode the string,  I need to code and decode to be able to pass special characters in the API
                string decodedStr = Encrypt.DeCodeBase64(str);
                //I used a regex to evaluate when a character is alphabetic including ñ or Ñ
                Regex regex = new Regex(@"[A-Za-zÑñ]");
                string result = "";
                string word = "";
                string wordParsed = "";

                //I iterate along the string
                foreach (Char chr in decodedStr)
                {
                    //Evalueates the first char
                    if (regex.IsMatch(chr.ToString()))
                    {
                        //Its alphabetic, I add the char in the word variable to create a new string
                        word += chr.ToString();
                    }
                    else
                    {
                        //We have a non alphabetic char,  it means that we have a separator
                        if (word.Length > 0)
                        {
                            //if the word contains more than  one character, we process it
                            wordParsed = word.Substring(0, 1) + (word.Length > 1 ? word[1..^1].ToUpper().Distinct().Count().ToString() : "0") + word.Substring(word.Length - 1, 1);
                        }
                        //Add the word parsed plus the separator,  if the word variable doesnt have characters their values is ""
                        result = result + wordParsed + chr.ToString();
                        word = "";
                        wordParsed = "";
                    }
                }
                //here we process the final word if has more than one character
                if (word.Length > 0)
                {
                    wordParsed = word.Substring(0, 1) + (word.Length > 1 ? word[1..^1].ToUpper().Distinct().Count().ToString() : "0") + word.Substring(word.Length - 1, 1);
                    result += wordParsed;
                }
                return result;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
