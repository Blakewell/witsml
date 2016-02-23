﻿using System.Collections.Generic;
using Avro.IO;
using Energistics.Common;
using Energistics.Datatypes;

namespace Energistics.Protocol.Core
{
    public class CoreClientHandler : EtpProtocolHandler, ICoreClient
    {
        public CoreClientHandler() : base(Protocols.Core, "client")
        {
            RequestedRole = "server";
            ServerProtocols = new List<SupportedProtocol>(0);
        }

        public IList<SupportedProtocol> ServerProtocols { get; private set; }

        public virtual void RequestSession(string applicationName, IList<SupportedProtocol> requestedProtocols)
        {
            var header = CreateMessageHeader(Protocols.Core, MessageTypes.Core.RequestSession);

            var requestSession = new RequestSession()
            {
                ApplicationName = applicationName,
                RequestedProtocols = requestedProtocols
            };

            Session.SendMessage(header, requestSession);
        }

        public virtual void CloseSession(string reason = null)
        {
            var header = CreateMessageHeader(Protocols.Core, MessageTypes.Core.CloseSession);

            var closeSession = new CloseSession()
            {
                Reason = reason ?? "Session closed"
            };

            Session.SendMessage(header, closeSession);
        }

        public event ProtocolEventHandler<OpenSession> OnOpenSession;

        public event ProtocolEventHandler<CloseSession> OnCloseSession;

        protected override void HandleMessage(MessageHeader header, Decoder decoder)
        {
            switch (header.MessageType)
            {
                case (int)MessageTypes.Core.OpenSession:
                    HandleOpenSession(header, decoder.Decode<OpenSession>());
                    break;

                case (int)MessageTypes.Core.CloseSession:
                    HandleCloseSession(header, decoder.Decode<CloseSession>());
                    break;

                default:
                    base.HandleMessage(header, decoder);
                    break;
            }
        }

        protected virtual void HandleOpenSession(MessageHeader header, OpenSession openSession)
        {
            Notify(OnOpenSession, header, openSession);

            ServerProtocols = openSession.SupportedProtocols;
            Session.SessionId = openSession.SessionId;
        }

        protected virtual void HandleCloseSession(MessageHeader header, CloseSession closeSession)
        {
            Notify(OnCloseSession, header, closeSession);
            Session.Close(closeSession.Reason);
        }
    }
}