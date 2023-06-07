using System;
namespace gamezone_api.Helpers
{
	public static class ListExtension
	{
        private static Random rng = new Random();

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var listCopy = new List<T>(list);
            int n = listCopy.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = listCopy[k];
                listCopy[k] = listCopy[n];
                listCopy[n] = value;
            }
            return listCopy;
        }
    }
}
