using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LikeSport.Model;
using LikeSport.Web.Models;

namespace LikeSport.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateActivity(this Activity one, ActivityViewModel two)
        {
   
            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;
    
        }
        public static void UpdateAccount(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateActivityGroup(this ActivityGroup one, ActivityGroupViewModel two)
        {

            one.Id = two.Id;
            one.ActivityGroupName = two.ActivityGroupName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;

        }
        public static void UpdateActivityInformation(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateAddress(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateChatInformation(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateDevice(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateFeedback(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateNotification(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdatePromotion(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateRate(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateReview(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
        public static void UpdateService(this Activity one, ActivityViewModel two)
        {

            one.Id = two.Id;
            one.ActivityName = two.ActivityName;
            one.State = two.State;
            one.CreatedDate = two.CreatedDate;
            one.ModifiedDate = two.ModifiedDate;
            one.CreatedBy = two.CreatedBy;
            one.ModifiedBy = two.ModifiedBy;
            one.ActivityGroup_Id = two.ActivityGroup_Id;

        }
    }
}