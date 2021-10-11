using System;

namespace Spaceman
{
    public class Game
    {
        public String Codeword {get; set; }
        public String CurrentWord {get; set; }
        public int MaxGuesses { get; set; }
        public int CurrentGuesses { get; set; }
        public string[] CodewordOptions = {"pocket", "willpower", "assignment", "tycoon", "cheap", "family"};
        public Ufo ovni;

        public Game() {
            Random random = new Random();
            int position = random.Next(0,5); 
            Codeword = CodewordOptions[position];
            MaxGuesses = 5;
            CurrentGuesses = 0;
            CurrentWord=CreateCurrentword(Codeword.Length);
            ovni = new Ufo();
        }

        public string CreateCurrentword(int length) {
            string output="";
            for (int i=0; i<length; i++) {
                output+="_";
            }
            return output;
        }

        public void Greet() {
            Console.WriteLine("Welcome to UFO: The Game");
            Console.WriteLine("GL HF!!");
        }

        public bool DidWin() {
            bool output = Codeword.Equals(this.CurrentWord) ? true : false;
            return output;
        }
        public bool DidLose() {
            bool output = CurrentGuesses>=this.MaxGuesses ? true : false;
            return output;
        }
        public void Display() {
            Console.WriteLine(ovni.Stringify());
            Console.WriteLine("Your actual progress: "+CurrentWord);
            Console.WriteLine("Remaining attempts: "+ (MaxGuesses-CurrentGuesses) );
        }
        public void Ask() {
            string letter;
            Console.Write("Guess the letter: ");
            letter=Console.ReadLine();
            if (letter.Length!=1) {
                return;
            }
            if (Codeword.Contains(letter)) {
                for (int j=0; j<Codeword.Length; j++) {
                    if (Codeword[j]==letter[0]) {
                        CurrentWord = CurrentWord.Remove(j,1).Insert(j, letter);
                    }
                }
            } else {
                CurrentGuesses++;
                ovni.AddPart();
            }
        }
    }
}