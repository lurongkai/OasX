using System;

namespace OasX.Domain
{
    public class SubjectPin : IEntity<Course>
    {
        public int SubjectPinId { get; set; }
        public Guid SubjectId { get; set; }
        public string PinName { get; set; }
    }
}