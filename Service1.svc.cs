using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http;
using HtmlAgilityPack;
using Snowball;
using System.Collections.Concurrent;





namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private static readonly HashSet<string> StopWords = new HashSet<string>
    {
        "a", "an", "the", "and", "or", "but", "if", "then", "while", "to", "in", "on", "at", "by", "for", "with",
        "about", "against", "between", "into", "through", "during", "before", "after", "above", "below",
        "from", "up", "down", "out", "over", "under", "again", "further", "then", "once", "here", "there", "all",
        "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not", "only",
        "own", "same", "so", "than", "too", "very", "s"
    };

        //first required service #5
        public List<string> Top10ContentWords(string input)
        {

            string text = "";

            //check first if our input is an URL
            if (input.StartsWith("http")) text = convertWebPageContent(input);
            //check if our input is final 
            else if (File.Exists(input)) text = File.ReadAllText(input);
            //otherwise it is a raw string
            else
            {
                text = input;
            }

            var tokenizedWords = tokenizeWords(text);
            var filterWords = removeStopWords(tokenizedWords);
            var stemmedWords = convertToStemWords(filterWords);


            var topTenList = mostFreq(stemmedWords);
            return topTenList;
        }

        private static string convertWebPageContent(string URL)
        {

            using (HttpClient client = new HttpClient())
            {

                //getStringAsync sends a GET request to the URL provided, downloads the content of the web page as a string, retrieves HTML source of the webpage
                var source = client.GetStringAsync(URL).Result;
                //we use HtmlDocument to extract data from URL easily
                HtmlDocument doc = new HtmlDocument();
                //we pass the raw unfilterd HTML text into structred format that is easier to follow
                doc.LoadHtml(source);
                return doc.DocumentNode.InnerText;
            }
        }
        private static List<string> tokenizeWords(string text)
        {
            //converting the text to lower case and removing all non alphabetic values
            var words = Regex.Matches(text.ToLower(), @"\b[a-z]+\b")
                             .Cast<Match>()
                             .Select(m => m.Value)
                             .ToList();
            //returns a list
            return words;

        }
        private static List<string> removeStopWords(List<string> words)
        {

            List<String> stoppedWordsRemoved = new List<string>();

            //goes thorugh list of words and adds words to new list that are not stop words
            foreach (string word in words)
            {
                if (!StopWords.Contains(word))
                {
                    stoppedWordsRemoved.Add(word);
                }
            }

            return stoppedWordsRemoved;

        }

        private static List<string> convertToStemWords(List<string> filterWords)
        {
            //using PorterStemmer to filter words and retrieve stem of the word
            var snowball = filterWords.Select(word => PorterStemmer.Porter.GetStem(word)).ToList();
            return snowball;
        }

        private List<string> mostFreq(List<string> words)
        {

            //returns the 10 most frequent words
            var wordFrequencies = words.GroupBy(w => w)
                                   .Select(g => new { Word = g.Key, Count = g.Count() })
                                   .OrderByDescending(w => w.Count)
                                   .Take(10)
                                   .Select(w => w.Word)
                                   .ToList();
            return wordFrequencies;
        }


        //second requird servcice #3
        
        public string stemming(string s)
        {

            //use the porterstemming logic to find the stem of the word
            var word = tokenizeWords(s);
            var stemmed = convertToStemWords(word);

            string words = string.Join(" ", stemmed);
            return words;
        }




        //Elective service 1
        public Boolean isPalindrome(String sentence)
        {

            //removing white space and numbers
            sentence = sentence.ToLower();
            sentence = Regex.Replace(sentence, @"\s+", "");
            sentence = Regex.Replace(sentence, "[^a-zA-Z]", "");

            int i = 0;
            int j = sentence.Length - 1;

            //use 2 pointer technique to check whether string is a palindrome
            while (i < j)
            {
                if (sentence[i] != sentence[j]) return false;
                i++;
                j--;
            }
            return true;
        }


        //Elective service 2

        //simple quick sort implementation
        //takes a string in the format of 1,2,3,4 and sorts
        public string sort(string s)
        {
            int i = 0;
            int length = 1;
            while (i < s.Length)
            {
                if (s[i] == ',') length++;
                i++;
            }


            int[] a = new int[length];
            int j = 0;
            i = 0;

            while (i < s.Length)
            {


                while (i < s.Length && s[i] == '0' && (i + 1 < s.Length && s[i + 1] != ','))
                {
                    i++;
                }



                string tempString = "";

                if (s[i] == '-')
                {
                    tempString += '-';
                    i++;
                }

                while (i < s.Length && s[i] != ',')
                {
                    tempString += s[i];
                    i++;
                }

                a[j] = int.Parse(tempString);
                j++;
                i++;
            }
            quickSort(a, 0, a.Length - 1);

            String n = "";
            int temp = 0;
            i = 0;
            while (i < length - 1)
            {

                temp = a[i];

                n = n + Convert.ToString(temp) + ',';
                i++;
            }
            temp = a[length - 1];
            n += Convert.ToString(temp);
            return n;
        }
        private void quickSort(int[] nums, int left, int right) {

            if (left < right)
                {
                    int pivot = partition(nums, left, right);
                    quickSort(nums, left, pivot - 1);
                    quickSort(nums, pivot + 1, right);

                }
        }
        private int partition(int[] a, int left, int right)
        {
            int pivot = a[right];
            int i = left - 1;
            int temp = 0;

            for (int j = i + 1; j < right; j++)
            {

                if (a[j] <= pivot)
                {

                    i++;
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }

            temp = a[right];
            a[right] = a[i + 1];
            a[i + 1] = temp;


            return i + 1;
        }

       


    }
}
