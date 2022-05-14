namespace API_internship
{
    public static class PostsListHelper
    {
        private static List<Post> _list;

        static PostsListHelper()
        {
            _list = ApiHelper<Post>.GetAll("https://jsonplaceholder.typicode.com/posts/");
        }

        public static void Record(Post value)
        {
            value.Id = _list.Count + 1;
            _list.Add(value);
        }

        public static List<Post> Posts()
        {
            return _list;
        }
    }
}
