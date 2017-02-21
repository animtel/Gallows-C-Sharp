//|---------------------------------------------------------------|
//|                       HANGMAN GAME                            |
//|         Developed by Yewondwossen Tadesse(Wonde)              |  
//|                                 Version 1.0.0.0               |
//|                                 Copyright ©  2010             |
//|---------------------------------------------------------------|
//|                       HANGMAN GAME                            |
//|---------------------------------------------------------------|
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_Game
{
    /// <summary>
    /// Class which holds a collection of words for the hangman game
    /// </summary>
    public class Words : List<Word>
    {
        /// <summary>
        /// Class which holds a collection of words for the hangman game 
        /// </summary>
        public Words()
        {
            this.Add(new Word() { Content = "LOL" });
            //this.Add(new Word() { Content = "THREE" });
            //this.Add(new Word() { Content = "VACATION" });
            //this.Add(new Word() { Content = "INFORMATION" });
            //this.Add(new Word() { Content = "TECHNOLOGY" });
            //this.Add(new Word() { Content = "ORLANDO" });
            //this.Add(new Word() { Content = "COMPUTER" });
            //this.Add(new Word() { Content = "ROUTER" });
            //this.Add(new Word() { Content = "PRINTER" });
            //this.Add(new Word() { Content = "BUDGE" });
            //this.Add(new Word() { Content = "SOFTWARE" });
            //this.Add(new Word() { Content = "HARDWARE" });
            //this.Add(new Word() { Content = "OBJECTIVE" });
            //this.Add(new Word() { Content = "FILE" });
            //this.Add(new Word() { Content = "EMPLOYEE" });
            //this.Add(new Word() { Content = "SECURITY" });
            //this.Add(new Word() { Content = "DATA" });
            //this.Add(new Word() { Content = "REPORT" });
            //this.Add(new Word() { Content = "PROPERTY" });
            //this.Add(new Word() { Content = "OWNERSHIP" });
        }

        /// <summary>
        /// Pick a random word
        /// </summary>
        /// <returns></returns>
        public Word Pick
        {
            get
            {
                Random RandomPick = new Random();
                int index = (int)(RandomPick.NextDouble() * this.Count);
                Word word = this[index];
                word.Content = word.Content.ToUpper();
                return word;
            }
        }
    }
}
