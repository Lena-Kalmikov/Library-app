using System;

namespace BookLib
{
    [Flags]
    public enum GenreType
    {
        None = 0, // without the 'none', the default value will be set to 'Action', and we don't want that.
        Action = 1,
        Adventure = 2,
        Comedy = 4,
        Crime = 8,
        Drama = 16,
        EpicPoetry = 32,
        Fantasy = 64,
        FolkTales = 128,
        Historical = 256,
        Horror = 512,
        Mystery = 1024,
        Romance = 2048,
        ScienceFiction = 4096,
        Tragedy = 8192,
    }
}
