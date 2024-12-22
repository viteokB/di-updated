using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordHandlers.MyStem;
using WordHandlers.MyStem.InfoClasses;

namespace Tests.WordHandlersTests.TestDatas
{
    public static class MyStemAnalyzerTestData
    {
        // Существительные
        public static IEnumerable<TestCaseData> Nouns()
        {
            yield return new TestCaseData(new List<string> { "кот" }, new List<WordInfo> { new WordInfo("кот", PartOfSpeech.S, "кот") });
            yield return new TestCaseData(new List<string> { "дом" }, new List<WordInfo> { new WordInfo("дом", PartOfSpeech.S, "дом") });
        }

        //Глаголы
        public static IEnumerable<TestCaseData> Verbs()
        {
            yield return new TestCaseData(new List<string> { "бежать" }, new List<WordInfo> { new WordInfo("бежать", PartOfSpeech.V, "бежать") });
            yield return new TestCaseData(new List<string> { "спать" }, new List<WordInfo> { new WordInfo("спать", PartOfSpeech.V, "спать") });
        }

        // Прилагательные
        public static IEnumerable<TestCaseData> Adjectives()
        {
            yield return new TestCaseData(new List<string> { "счастливый" }, new List<WordInfo> { new WordInfo("счастливый", PartOfSpeech.A, "счастливый") });
            yield return new TestCaseData(new List<string> { "синий" }, new List<WordInfo> { new WordInfo("синий", PartOfSpeech.A, "синий") });
        }

        //Наречия
        public static IEnumerable<TestCaseData> Adverbs()
        {
            yield return new TestCaseData(new List<string> { "быстро" }, new List<WordInfo> { new WordInfo("быстро", PartOfSpeech.ADV, "быстро") });
            yield return new TestCaseData(new List<string> { "осторожно" }, new List<WordInfo> { new WordInfo("осторожно", PartOfSpeech.ADV, "осторожно") });
        }

        // Смешанные слова
        public static IEnumerable<TestCaseData> MixedWords()
        {
            yield return new TestCaseData(
                new List<string> { "кот", "бежать", "счастливый", "быстро" },
                new List<WordInfo>
                {
                    new WordInfo("кот", PartOfSpeech.S, "кот"),
                    new WordInfo("бежать", PartOfSpeech.V, "бежать"),
                    new WordInfo("счастливый", PartOfSpeech.A, "счастливый"),
                    new WordInfo("быстро", PartOfSpeech.ADV, "быстро")
                }
            );

            yield return new TestCaseData(
                new List<string> { "дом", "спать", "синий", "осторожно" },
                new List<WordInfo>
                {
                    new WordInfo("дом", PartOfSpeech.S, "дом"),
                    new WordInfo("спать", PartOfSpeech.V, "спать"),
                    new WordInfo("синий", PartOfSpeech.A, "синий"),
                    new WordInfo("осторожно", PartOfSpeech.ADV, "осторожно")
                }
            );
        }
    }
}
