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
    public class DocxFileReaderTests : BaseFileReaderTests
    {
        protected override string FilesDirectoryName => "docxFiles";

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void DocxFileReader_Read_ShouldReadNormalDocxCorrect()
        {
            var docxReader = new DocxFileReader(@$"{GetFilesParentDir}/docx1_correct.docx");

            Approvals.Verify(CreateWordsOutput(docxReader.Read()));
        }

        [Test]
        public void DocxFileReader_Read_ShouldThrowExceptionOnWrongDocx()
        {
            var docxReader = new DocxFileReader(@$"{GetFilesParentDir}/docx_not_one_word_inline.docx");
            Action act = () => docxReader.Read();
            act.Should().Throw<Exception>()
                .WithMessage("The docx file must contain no more than one word per line!");
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void DocxFileReader_Read_ShouldReadDocxWithEmptyLinesCorrect()
        {
            var docxReader = new DocxFileReader(@$"{GetFilesParentDir}/docx_with_emptyline.docx");

            Approvals.Verify(CreateWordsOutput(docxReader.Read()));
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void DocxFileReader_Read_ShouldReadDocxWithWhiteSpacesCorrect()
        {
            var docxReader = new DocxFileReader(@$"{GetFilesParentDir}/docx_trim_spaces.docx");

            Approvals.Verify(CreateWordsOutput(docxReader.Read()));
        }
    }
}
