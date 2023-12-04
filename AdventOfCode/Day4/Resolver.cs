namespace AdventOfCode.Day4
{
    public class Resolver : BaseResolver
    {
        public Resolver() : base(4) { }

        public override object ResolvePuzzle1() => BuildCardData().Sum(_ => _.ComputePoints());

        public override object ResolvePuzzle2()
        {
            var cardData = BuildCardData();

            for (int i = 0; i < cardData.Count; i++)
            {
                for (int j = 0; j < cardData[i].Copies; j++)
                {
                    CreateCopies(i, cardData);
                }
            }

            return cardData.Select(_ => _.Copies).Sum();
        }

        private List<Card> BuildCardData()
        {
            return Data
                .Select(
                    _ => _.Split(new char[] { ':', '|' }).Skip(1).Take(2)).ToList()
                .Select(
                    (_, gameIndex) => new Card(gameIndex + 1, BuildNumberData(1, _), BuildNumberData(0, _))
            ).ToList();
        }

        private IEnumerable<int> BuildNumberData(int index, IEnumerable<string> numbersToBeParsed)
        {
            return numbersToBeParsed.ToList()[index].Split(" ").Where(
                _ => !string.IsNullOrWhiteSpace(_)
            ).Select((_, index) => int.Parse(_));
        }

        private void CreateCopies(int cardIndex, List<Card> cardList)
        {
            var numberOfCopiesToBeCreated = cardList[cardIndex].CommonNumbers;

            for (int index = 0; index < numberOfCopiesToBeCreated; index++)
            {
                cardList[index + cardIndex + 1].Copies++;   
            }
        }

    }
}
