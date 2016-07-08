using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace RemoteBrainTeaser
{
    [MethodCallInterceptor]
    public partial class TestMe : ContextBoundObject, IInterceptMethodCall
    {
        public bool TryIntercept(IMethodReturnMessage message, out object returnValue)
        {
            if (string.Equals(message.MethodName, nameof(GetAnswer), StringComparison.Ordinal))
            {
                returnValue = 42;
                return true;
            }
            if (string.Equals(message.MethodName, nameof(Inconceivable), StringComparison.Ordinal))
            {
                returnValue = message.GetArg(1);
                return true;
            }
            returnValue = null;
            return false;
        }
    }

    public interface IInterceptMethodCall
    {
        bool TryIntercept(IMethodReturnMessage message, out object returnValue);
    }

    public class MethodCallInterceptorAttribute : ContextAttribute, IContributeObjectSink
    {
        public MethodCallInterceptorAttribute() : base(nameof(MethodCallInterceptorAttribute))
        {
        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new MessageSink((IInterceptMethodCall)obj, nextSink);
        }

        private class MessageSink : IMessageSink
        {
            private readonly IInterceptMethodCall _interceptor;
            public IMessageSink NextSink { get; }

            public MessageSink(IInterceptMethodCall obj, IMessageSink nextSink)
            {
                _interceptor = obj;
                NextSink = nextSink;
            }

            public IMessage SyncProcessMessage(IMessage msg)
            {
                IMessage message = NextSink.SyncProcessMessage(msg);
                var returnMessage = message as IMethodReturnMessage;
                object returnValue;
                if (returnMessage != null && _interceptor.TryIntercept(returnMessage, out returnValue))
                {
                    return new MethodReturnMessageWrapper(returnMessage) {ReturnValue = returnValue};
                }
                return message;
            }

            public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
            {
                throw new NotImplementedException();
            }
        }
    }
}