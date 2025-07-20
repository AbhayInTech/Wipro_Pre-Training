using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Text_to_Speech
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a new inatance of the SpeechSyynthesizer class
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            //creating an object of the SpeechSynthesizer class
            Console.WriteLine("Enter the text you want to convert to speech : ");
            string text = Console.ReadLine();
            //get the text from the user
            synthesizer.Speak(text);
            //converting the text to Speech
            //changing the voice pace
            synthesizer.SelectVoiceByHints(VoiceGender.Female);
            synthesizer.Speak(text);
            synthesizer.SetOutputToWaveFile("output.wav");
        }
    }
}
