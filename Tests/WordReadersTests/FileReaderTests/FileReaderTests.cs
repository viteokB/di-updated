﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using FluentAssertions;
using WordReaders.Readers;

namespace Tests.WordReadersTests.FileReaderTests
{
    [TestFixture]
    public class FileReaderTests : BaseFileReaderTests
    {
        protected override string FilesDirectoryName => "txtFiles";

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void FileReader_Read_ShouldReadNormalTxtCorrect()
        {
            var fileReader = new FileReader(@$"{GetFilesParentDir}/txt1_correct.txt", Encoding.UTF8);

            Approvals.Verify(CreateWordsOutput(fileReader.Read()));
        }

        [Test]
        public void FileReader_Read_ShouldThrowExceptionOnWrongTxt()
        {
            var fileReader = new FileReader(@$"{GetFilesParentDir}/txt_not_one_word_inline.txt", Encoding.UTF8);
            Action act = () => fileReader.Read();

            act.Should().Throw<Exception>()
                .WithMessage("The file must contain no more than one word per line!");
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void FileReader_Read_ShouldReadTxtWithEmptyLinesCorrect()
        {
            var fileReader = new FileReader(@$"{GetFilesParentDir}/txt_with_emptyline.txt", Encoding.UTF8);

            Approvals.Verify(CreateWordsOutput(fileReader.Read()));
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void FileReader_Read_ShouldReadTxtWithWhiteSpacesCorrect()
        {
            var fileReader = new FileReader($@"{GetFilesParentDir}/txt_trim_spaces.txt", Encoding.UTF8);

            Approvals.Verify(CreateWordsOutput(fileReader.Read()));
        }
    }
}
