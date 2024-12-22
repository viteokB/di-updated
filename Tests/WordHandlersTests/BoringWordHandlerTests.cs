using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tests.WordHandlersTests.TestDatas;
using WordHandlers.Handlers;
using WordHandlers.MyStem;
using WordHandlers.MyStem.InfoClasses;

namespace Tests.WordHandlersTests
{
    [TestFixture]
    public class BoringWordHandlerTests
    {
        private BoringWordHandler boringHandler;

        [SetUp]
        public void SetUp()
        {
            boringHandler = new BoringWordHandler();
        }

        [TearDown]
        public void TearDown()
        {
            boringHandler.Dispose();
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Nouns))]
        public void BoringWordHandler_ApplyWordHandlerWithNouns_ReturnsNotEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Adjectives))]
        public void BoringWordHandler_ApplyWordHandlerWithAdjectives_ReturnsNotEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Verbs))]
        public void BoringWordHandler_ApplyWordHandlerWithVerbs_ReturnsNotEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Numerals))]
        public void BoringWordHandler_ApplyWordHandlerWithNumerals_ReturnsNotEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Pronouns))]
        public void BoringWordHandler_ApplyWordHandlerWithPronouns_ReturnsEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Adverbs))]
        public void BoringWordHandler_ApplyWordHandlerWithAdverbs_ReturnsEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Conjunctions))]
        public void BoringWordHandler_ApplyWordHandlerWithConjunctions_ReturnsEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Prepositions))]
        public void BoringWordHandler_ApplyWordHandlerWithPrepositions_ReturnsEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }


        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Interjections))]
        public void BoringWordHandler_ApplyWordHandlerWithInterjections_ReturnsEmptyLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.Particles))]
        public void BoringWordHandler_ApplyWordHandlerWithParticles_ReturnsEmpryLemmas(List<string> inputWords, List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }

        [TestCaseSource(typeof(BoringWordTestData), nameof(BoringWordTestData.MixedWords))]
        public void BoringWordHandler_ApplyWordHandlerWithMixedWords_ShouldReturnCorrectLemmas(List<string> inputWords,
            List<string> expectedWords)
        {
            var actualResult = BoringWordHandler.ApplyWordHandler(inputWords);

            actualResult.Should().BeEquivalentTo(expectedWords);
        }
    }
}
