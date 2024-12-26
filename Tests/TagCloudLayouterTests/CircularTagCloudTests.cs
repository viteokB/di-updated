﻿using System.Drawing;
using NUnit.Framework.Interfaces;
using TagCloud;
using TagCloud.RayMovers;
using TestHelpers.TagCloudLayouterTests.Helpers.RectangleOnlyVisualiser;
using Tests.TagCloudLayouterTests.TestHelpers;

namespace Tests.TagCloudLayouterTests;

[TestFixture]
public class CircularTagCloudTests : BaseTagCloudTests
{
    [SetUp]
    public override void Setup()
    {
        _center = new Point(WIDTH / 2, HEIGHT / 2);

        var mover = new CircularSpiralPointCreator(_center);

        _layouter = new TagCloudLayouter(mover);

        _visualiser = new RectangleVisualiser(Color.Black, 1);

        _tagCloudImageGenerator = new TagCloudImageGenerator(_visualiser);

        _errorImageSize = new Size(WIDTH, HEIGHT);
    }

    [TearDown]
    public override void Teardown()
    {
        if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
        {
            using var errorBitmap = _tagCloudImageGenerator.CreateNewBitmap(_errorImageSize, _layouter.Rectangles);

            var fileName = $"{TestContext.CurrentContext.Test.MethodName + Guid.NewGuid()}.png";
            BitmapSaver.SaveToFail(errorBitmap, "Circular", fileName);
        }
        else if (_layouter.Rectangles.Count > 0)
        {
            using var correctBitmap = _tagCloudImageGenerator.CreateNewBitmap(_errorImageSize, _layouter.Rectangles);

            var fileName = $"{TestContext.CurrentContext.Test.MethodName + Guid.NewGuid()}.png";
            BitmapSaver.SaveToCorrect(correctBitmap, "Circular", fileName);
        }

        _visualiser.Dispose();
        _tagCloudImageGenerator.Dispose();
    }
}