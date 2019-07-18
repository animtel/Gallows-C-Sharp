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
            Console.WriteLine("Добро пожаловать в Висельницу. У вас есть 7 попыток, чтобы угадать слово.");
            string yesNo = string.Empty;
            do
            {
                Console.WriteLine();
                yesNo = playGame();
            } while (yesNo.ToUpper().Equals("Д"));
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
                Console.Write("Напиши букву --> ");
                ConsoleKeyInfo guessedLetter = Console.ReadKey();
                if (playHangman.AddGuessedLetters(guessedLetter.KeyChar))
                    playHangman.Play();
            }
            if (playHangman.Result() == GAMERESULT.LOSE)
            {
                Console.WriteLine("Вы проиграли :(");
                makeTextBlink("Загаданное слово было: '" + pickedWord.Content.ToUpper() + "'", 500);
                Console.WriteLine("Вы ходите сыграть еще раз ? Д/Н");
                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
            else
            {
                makeTextBlink("Вы выйграли !", 500);
                Console.WriteLine("Вы ходите сыграть еще раз ? Д/Н");
                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
        }
    }
}