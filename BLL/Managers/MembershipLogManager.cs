using System;
using System.Collections.Generic;
using DAL.Repositories;
using Models.Entities;

namespace BLL.Managers
{
    public class MembershipLogManager
    {
        private readonly MembershipLogRepository _membershipLogRepository;

        public MembershipLogManager()
        {
            _membershipLogRepository = new MembershipLogRepository();
        }

        /// <summary>
        /// Adds a new membership log entry.
        /// </summary>
        /// <param name="log">MembershipLog object containing log details.</param>
        /// <exception cref="ArgumentException">Thrown if the log details are invalid.</exception>
        public void AddMembershipLog(MembershipLog log)
        {
            ValidateMembershipLog(log);
            _membershipLogRepository.AddLog(log);
        }

        /// <summary>
        /// Retrieves all membership logs for a specific member.
        /// </summary>
        /// <param name="memberId">The ID of the member.</param>
        /// <returns>A list of MembershipLog objects.</returns>
        /// <exception cref="ArgumentException">Thrown if the MemberID is invalid.</exception>
        public List<MembershipLog> GetLogsByMemberId(int memberId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("MemberID must be greater than 0.");
            }

            return _membershipLogRepository.GetLogsByMemberId(memberId);
        }
        
        /// <summary>
        /// Retrieves all logs in the system.
        /// </summary>
        /// <returns>List of all membership logs.</returns>
        public List<MembershipLog> GetAllLogs()
        {
            return _membershipLogRepository.GetAllLogs();
        }

        /// <summary>
        /// Retrieves all membership logs within a specific date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of MembershipLog objects.</returns>
        /// <exception cref="ArgumentException">Thrown if the date range is invalid.</exception>
        public List<MembershipLog> GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date must be before end date.");
            }

            return _membershipLogRepository.GetLogsByDateRange(startDate, endDate);
        }

        /// <summary>
        /// Retrieves the most recent logs for all members.
        /// </summary>
        /// <param name="limit">The number of logs to retrieve.</param>
        /// <returns>A list of recent MembershipLog objects.</returns>
        /// <exception cref="ArgumentException">Thrown if the limit is invalid.</exception>
        public List<MembershipLog> GetRecentLogs(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("Limit must be greater than 0.");
            }

            return _membershipLogRepository.GetRecentLogs(limit);
        }

        /// <summary>
        /// Validates a membership log entry.
        /// </summary>
        /// <param name="log">The membership log object to validate.</param>
        /// <exception cref="ArgumentException">Thrown if the log details are invalid.</exception>
        private void ValidateMembershipLog(MembershipLog log)
        {
            if (log.MemberID <= 0)
            {
                throw new ArgumentException("MemberID must be greater than 0.");
            }

            if (log.EventDate == default)
            {
                throw new ArgumentException("Event date is required.");
            }

            if (!IsValidEventType(log.EventType))
            {
                throw new ArgumentException($"Invalid event type: {log.EventType}. Valid types are 'Renewed', 'Cancelled', 'Expired'.");
            }
        }

        /// <summary>
        /// Checks if an event type is valid.
        /// </summary>
        /// <param name="eventType">The event type to check.</param>
        /// <returns>True if the event type is valid; otherwise, false.</returns>
        private bool IsValidEventType(string eventType)
        {
            return MembershipLogEventTypes.ValidEventTypes.Contains(eventType);
        }
    }

    /// <summary>
    /// Defines and manages valid membership log event types.
    /// </summary>
    public static class MembershipLogEventTypes
    {
        public const string Renewed = "Renewed";
        public const string Cancelled = "Cancelled";
        public const string Expired = "Expired";

        public static readonly HashSet<string> ValidEventTypes = new HashSet<string> { Renewed, Cancelled, Expired };
    }
    
    
}
