using System;

namespace DemoEFCore.BaseRepository
{
    public class BaseEntity : IBaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; } = false;
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid CreatedById { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public Guid? UpdatedById { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        public Guid? DeletedById { get; set; }
    }
}
