using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.MaxLetters {
    public abstract class MaxLettersForBoxTestFixtureBase {
        protected abstract WordSearchBox TestSearchBox { get; }

        public virtual void TestLeftWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new LeftWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestRightWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new RightWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new DownWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new UpWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestDiagonallyRightDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new DiagonallyRightDownWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestDiagonallyLeftDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new DiagonallyLeftDownWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestDiagonallyRightUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new DiagonallyRightUpWordConstructor(startLetter, TestSearchBox));
        }
        public virtual void TestDiagonallyLeftUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            TestMaxLetters(maxLetters, new DiagonallyLeftUpWordConstructor(startLetter, TestSearchBox));
        }
        protected static void TestMaxLetters(int maxLetters, IWordConstructor wordConstructor) {
            Assert.AreEqual(maxLetters, wordConstructor.MaxLettersToSearch);
        }
    }
}