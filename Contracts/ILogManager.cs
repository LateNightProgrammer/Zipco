using System;

namespace Contracts
{
    public interface ILogManager    
    {
        void Info(string message);
        void Debug(string message);
        void Error(string message);

    }
}
