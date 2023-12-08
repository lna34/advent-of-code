namespace AdventOfCode.Day4
{
    public class Resolver : BaseResolver
    {
        private readonly Card[] _cardData;
        public Resolver() : base(4)
        {
            _cardData = BuildCardData();
        }

        public override object ResolvePuzzle1() => _cardData.Sum(_ => _.ComputePoints());
        public override object ResolvePuzzle2() => GetCardCopies();

        private int GetCardCopies()
        {
            for (int cardIndex = 0; cardIndex < _cardData.Length; cardIndex++)
            {
                var card = _cardData[cardIndex];
                for (int commonIndex = 0; commonIndex < card.CommonNumbers; commonIndex++)
                {
                    _cardData[cardIndex + commonIndex + 1].Copies += card.Copies;
                }
            }

            return _cardData.Sum(_ => _.Copies);
        }

        private Card[] BuildCardData()
        {
            return data
                .Select(
                    _ => _.Split(new char[] { ':', '|' }).Skip(1).Take(2)).ToList()
                .Select(
                    (_, gameIndex) => new Card(gameIndex + 1, BuildNumberData(1, _), BuildNumberData(0, _))
            ).ToArray();
        }

        private IEnumerable<int> BuildNumberData(int index, IEnumerable<string> numbersToBeParsed)
        {
            return numbersToBeParsed.ToList()[index].Split(" ").Where(
                _ => !string.IsNullOrWhiteSpace(_)
            ).Select((_, index) => int.Parse(_));
        }
    }
}
