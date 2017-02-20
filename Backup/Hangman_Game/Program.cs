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
using System.Threading;

namespace Hangman_Game
{
    /// <summary>
    /// Main Program class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to hangman. You get seven chances to guess the mystery word.");
            string yesNo = string.Empty;
            do
            {
                Console.WriteLine();
                yesNo = playGame();
            } while (yesNo.ToUpper().Equals("Y"));
        }

        /// <summary>
        /// Make text to be blink
        /// </summary>
        /// <param name="text">Text to be blinked</param>
        /// <param name="delay">Deley time value</param>
        static void makeTextBlink(string text, int delay)
        {
            for (int i = 0; i < 5; i++)
            {
                writeBlinkingText(text, delay, true);
                writeBlinkingText(text, 500, false);
            }
        }

        /// <summary>
        /// Write blinking text
        /// </summary>
        /// <param name="text">Text to be blinked</param>
        /// <param name="delay">Delay time value</param>
        /// <param name="visible">Set visiblity of the text</param>
        private static void writeBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            Thread.Sleep(delay);
        }

        /// <summary>
        /// Play game
        /// </summary>
        private static string playGame()
        {
            Words words = new Words();
            Word pickedWord = words.Pick;
            PlayHangman playHangman = new PlayHangman();
            playHangman.PickedWord = pickedWord;
            ConsoleKeyInfo yesNo = new ConsoleKeyInfo();
            for (int i = 0; i < pickedWord.WordLength; i++)
            {
                Console.Write(" _ ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            while (playHangman.Result() == GAMERESULT.CONTINUE)
            {
                Console.Write("Pick a letter --> ");
                ConsoleKeyInfo guessedLetter = Console.ReadKey();
                if (playHangman.AddGuessedLetters(guessedLetter.KeyChar))
                    playHangman.Play();
            }
            if (playHangman.Result() == GAMERESULT.LOSE)
            {
                Console.WriteLine("So sorry. You struck out.");
                makeTextBlink("The mystery word was '" + pickedWord.Content.ToUpper() + "'", 500);
                Console.WriteLine("Do you want to play again ? Y/N");
                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
            else
            {
                makeTextBlink("You won !", 500);
                Console.WriteLine("Do you want to play again ? Y/N");
                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
        }
    }
}