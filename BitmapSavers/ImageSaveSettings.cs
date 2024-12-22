﻿using System.Drawing;

namespace BitmapSavers;

public record ImageSaveSettings(Bitmap Bitmap, string Path, string Name, ImageSaveFormat Format);