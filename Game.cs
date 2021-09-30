using System;

namespace Spaceman
{
    class Game
    {
        private String _Codeword {get; set; }
        private String _CurrentWord {get; set; }
        private int _MaxGuesses { get; set; }
        private int _CurrentGuesses {get; set; }
        private string[] _CodewordOptions = {"pocket", "willpower", "assignment", "tycoon", "cheap", "family"};
        private Ufo ovni = new Ufo();

        public Game() {
            Random random = new Random();
            int position = random.Next(0,5); 
            this._Codeword = _CodewordOptions[position];
            this._MaxGuesses = 5;
            this._CurrentGuesses = 0;
            for (int i=0; i<this._Codeword.Length; i++) {
                this._CurrentWord+="_";
            }
        }

        public void Greet() {
            Console.WriteLine("Welcome to UFO: The Game");
            Console.WriteLine("GL HF!!");
        }

        public bool DidWin() {
            bool output = this._Codeword.Equals(this._CurrentWord) ? true : false;
            return output;
        }
        public bool DidLose() {
            bool output = this._CurrentGuesses>=this._MaxGuesses ? true : false;
            return output;
        }
        public void Display() {
            Console.WriteLine(ovni.Stringify());
            Console.WriteLine("Your actual progress: "+this._CurrentWord);
            Console.WriteLine("Remaining attempts: "+ (this._MaxGuesses-this._CurrentGuesses) );
        }
        public void Ask() {
            string letter;
            Console.Write("Guess the letter: ");
            letter=Console.ReadLine();
            if (letter.Length!=1) {
                return;
            }
            if (this._Codeword.Contains(letter)) {
                for (int j=0; j<this._Codeword.Length; j++) {
                    if (this._Codeword[j]==letter[0]) {
                        this._CurrentWord = this._CurrentWord.Remove(j,1).Insert(j, letter);
                    }
                }
            } else {
                this._CurrentGuesses++;
                ovni.AddPart();
            }
        }
    }
}