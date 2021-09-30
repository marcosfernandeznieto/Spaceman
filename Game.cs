using System;

namespace Spaceman
{
    class Game
    {
        public String Codeword {get; set; }
        public String CurrentWord {get; set; }
        public int MaxGuesses { get; set; }
        public int CurrentGuesses { get; set; }
        public string[] CodewordOptions = {"pocket", "willpower", "assignment", "tycoon", "cheap", "family"};
        public Ufo ovni = new Ufo();

        public Game() {
            Random random = new Random();
            int position = random.Next(0,5); 
            this.Codeword = CodewordOptions[position];
            this.MaxGuesses = 5;
            this.CurrentGuesses = 0;
            for (int i=0; i<this.Codeword.Length; i++) {
                this.CurrentWord+="_";
            }
        }

        public void Greet() {
            Console.WriteLine("Welcome to UFO: The Game");
            Console.WriteLine("GL HF!!");
        }

        public bool DidWin() {
            bool output = this.Codeword.Equals(this.CurrentWord) ? true : false;
            return output;
        }
        public bool DidLose() {
            bool output = this.CurrentGuesses>=this.MaxGuesses ? true : false;
            return output;
        }
        public void Display() {
            Console.WriteLine(ovni.Stringify());
            Console.WriteLine("Your actual progress: "+this.CurrentWord);
            Console.WriteLine("Remaining attempts: "+ (this.MaxGuesses-this.CurrentGuesses) );
        }
        public void Ask() {
            string letter;
            Console.Write("Guess the letter: ");
            letter=Console.ReadLine();
            if (letter.Length!=1) {
                return;
            }
            if (this.Codeword.Contains(letter)) {
                for (int j=0; j<this.Codeword.Length; j++) {
                    if (this.Codeword[j]==letter[0]) {
                        this.CurrentWord = this.CurrentWord.Remove(j,1).Insert(j, letter);
                    }
                }
            } else {
                this.CurrentGuesses++;
                ovni.AddPart();
            }
        }
    }
}