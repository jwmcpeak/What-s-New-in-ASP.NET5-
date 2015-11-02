using System.Collections.Generic;
using MessageApp.Models;

namespace MessageApp.Data
{
    public interface IMessageRepository
    {
        IEnumerable<Message> All();
        Message Get(int id);
        void Update(Message message);
    }
}