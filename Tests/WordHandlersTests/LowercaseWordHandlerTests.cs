using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tests.WordHandlersTests.TestDatas;
using WordHandlers.Handlers;

namespace Tests.WordHandlersTests
{
    [TestFixture]
    public class LowercaseWordHandlerTests
    {
        private LowercaseWordHandler lowercaseWordHandler;

        [OneTimeSetUp]
        protected void SetUp()
        {
            lowercaseWordHandler = new LowercaseWordHandler();
        }

        [TestCaseSource(typeof(LowercaseTestData), nameof(LowercaseTestData.OneWordCases))]
        public void LowercaseWordHandler_ApplyHandler_ShouldLowerOneWord(List<string> given, List<string> expected)
        {
            var actual = lowercaseWordHandler.ApplyWordHandler(given);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestCaseSource(typeof(LowercaseTestData), nameof(LowercaseTestData.FewWordsCases))]
        public void LowercaseWordHandler_ApplyHandler_ShouldLowerFewWords(List<string> given, List<string> expected)
        {
            var actual = lowercaseWordHandler.ApplyWordHandler(given);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
