using MessageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageApp.Data
{
    public class MessageRepository
    {
        private static List<Message> _messages = new List<Message>();
        static MessageRepository()
        {
            _messages.Add(new Message
            {
                Id = 1,
                Title = "First Message",
                Content = "This is the first message."
            });

            _messages.Add(new Message
            {
                Id = 2,
                Title = "Second Message",
                Content = "This is the second message."
            });
        }

        public IEnumerable<Message> All()
        {
            return _messages.ToArray();
        }

        public Message Get(int id)
        {
            return _messages.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Message message)
        {
            var existing = Get(message.Id);

            if (existing == null)
            {
                // TODO: do something
                return;
            }

            existing.Title = message.Title;
            existing.Content = message.Content;
        }
    }
}
