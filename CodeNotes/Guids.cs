// Guids.cs
// MUST match guids.h
using System;

namespace Likol.CodeNotes
{
    static class GuidList
    {
        public const string guidCodeNotesPkgString = "8f47ea04-c573-45c6-a1b5-e9eae1e861e7";
        public const string guidCodeNotesCmdSetString = "f4a6524b-e3f8-4501-b47e-23484f7c5f58";

        public static readonly Guid guidCodeNotesCmdSet = new Guid(guidCodeNotesCmdSetString);
    };
}