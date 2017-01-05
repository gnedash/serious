using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Serious.Users.AppCode
{
    public class UserManager
    {
        private static UserManager _instance;
        private static object _syncRoot = new object();
        private ConcurrentDictionary<string, string> _userSessionDict = new ConcurrentDictionary<string, string>();
        //private List<string> _expiredSessionList = new List<string>();

        private UserManager()
        {
        }

        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddUserSession(string sessionId, string userName)
        {
            if (_userSessionDict.Keys.Contains(sessionId))
                _userSessionDict.Keys.Remove(sessionId);

            _userSessionDict.TryAdd(sessionId, userName);
        }

        public void EndUserSession(string userEmail)
        {
            var endSessions = _userSessionDict.Where(kvs =>kvs.Value == userEmail);

            if (endSessions != null && endSessions.Count() > 0)
            {
                //var sessionIdList = endSessions.Select(kv => kv.Key);
                //lock (_syncRoot)
                //{
                //    _expiredSessionList.AddRange(sessionIdList);
                //}
                var returnVal = string.Empty;
                foreach (var sessionId in endSessions)
                    _userSessionDict.TryRemove(sessionId.Key, out returnVal);
            }
        }

        public void RemoveSession(string sessionId)
        {
            //lock (_syncRoot)
            //{
            //    _expiredSessionList.Remove(sessionId);
            //}
            var returnVal = string.Empty;
            if (_userSessionDict.ContainsKey(sessionId))
                _userSessionDict.TryRemove(sessionId, out returnVal);
        }

        //public bool CheckSessionExpired(string sessionId)
        //{
        //    return _expiredSessionList.Contains(sessionId);
        //}

        public bool CheckIsUserOnline(string email)
        {
            var onlineUsers = _userSessionDict.Where(kvs => kvs.Value == email);
            return onlineUsers != null && onlineUsers.Count() > 0;
        }
    }
}