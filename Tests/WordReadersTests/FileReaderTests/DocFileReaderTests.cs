using ApprovalTests.Reporters;
using ApprovalTests;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordReaders.Readers;

namespace Tests.WordReadersTests.FileReaderTests
{
    [TestFixture]
    public class DocFileReaderTests : BaseFileReaderTests
    {
        protected override string FilesDirectoryName => "docFiles";

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void DocFileReader_Read_ShouldReadNormalDocCorrect()
        {
            var docReader = new DocFileReader(@$"{GetFilesParentDir}/doc1_correct.doc");
            var data = docReader.Read();

            Approvals.Verify(CreateWordsOutput(data));
        }


        [Test]
        public void DocFileReader_Read_ShouldThrowExceptionOnWrongDoc()
        {
            var docReader = new DocFileReader(@$"{GetFilesParentDir}/doc_not_one_word_inline.doc");
            Action act = () => docReader.Read();
            act.Should().Throw<Exception>()
                .WithMessage("The doc file must contain no more than one word per line!");
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void DocFileReader_Read_ShouldReadDocWithEmptyLinesCorrect()
        {
            var docReader = new DocFileReader(@$"{GetFilesParentDir}/doc_with_emptyline.doc");
            Approvals.Verify(CreateWordsOutput(docReader.Read()));
        }


        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void DocFileReader_Read_ShouldReadDocWithWhiteSpacesCorrect()
        {
            var docReader = new DocFileReader(@$"{GetFilesParentDir}/doc_trim_spaces.doc");
            Approvals.Verify(CreateWordsOutput(docReader.Read()));
        }
    }
}
