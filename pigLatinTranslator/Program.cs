using System;
using System.Collections.Generic;

namespace pigLatinTranslator {
    class Program {
        static void Main(string[] args) {
            
            // declare string variable englishText to hold the 
            // english word or sentence to be translated
            string englishText = "beast dough happy question star three ade";

            // Define a few constant such as space and the type of character to rule with
            const string SPACE = " ";               // Define constant space to ensure correct spacing
            const string vowels = "aeiouAEIOU";     // Define constant vowels to list all available vowels
            const string specials = "qust";         // Define constant of two-letter special characters such as 'qu', 'st' ..

            string pigForm = "";                    // Declare string variable to hold the final translated Pig Latin
            string firstCharacter,specialCharacter;    // Declare string variable to hold the extracted first 
                                                       // character(s) of any particular word at a time
            string otherCharacters, others;         // this variables hold the other part of the separated word before re-combined 
            string[] words = englishText.Split(' ');    // with func Split(), break all any given sentences into single word or words arrays

            /**
             * Pick individual word from the array words and separate into 
             * either firstCharacter and otherCharacters or specialCharacter and others
             * in some cases of words like 'queen', 'question', 'straight'
             */
            foreach (string word in words) {
                firstCharacter = word.Substring(0, 1);
                specialCharacter = word.Substring(0,2);

                // Check if the first character of a word is a vowel
                bool isVowel = vowels.IndexOf(firstCharacter) >= 0;
                // Check if the first two characters is in the special defined above
                bool isSpecial = specials.IndexOf(specialCharacter) >= 0;

                otherCharacters = word.Substring(firstCharacter.Length, word.Length - 1);
                others = word.Substring(specialCharacter.Length, word.Length - 2);

                if (isVowel) {
                    pigForm += word + "way" + SPACE;
                }
                else if(isSpecial){
                    pigForm += others + specialCharacter + "ay" + SPACE;
                }
                else {
                    pigForm += otherCharacters + firstCharacter + "ay" + SPACE;
                }
            }
            Console.WriteLine(pigForm); // Output to the console the final result
            Console.ReadKey();
        }
    }
}
