using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.Enums
{
    public class Enums
    {
        public enum SurfaceArea
        {
            SQUARE_KILOMETERS = 1000
        }

        public enum SpatialPlanStatus
        {
            VALID = 1,
            IN_PROGRESS = 2,
            INVALID =3
        }


        public enum ZaraDocumentStatus
        {
            ALL = 0,
            PLANNED = 1,
            IN_PROGRESS = 2,
            VALID = 3,
            INVALID = 4,
            IN_ENACTMENT = 5, //faza donošenja
            UNKNOWN = 6
        }


        public enum GeometryType { MultiPolygon };
        public enum SpatialRevisionStatus
        {
            BASIC = 1,
            CHANGED = 2,
            REPORT = 3
        }

        public enum AdditionalDocumentSize
        {
            MB_100 = 100000000,
            MB_700 = 700000000,
        }

        public enum PlanDelivery
        {
            DELIVERED = 1,
            DELIVERED_WITHOUT_CD = 2,
            DELIVERED_WITHOUT_MAPS,
            DELIVERED_MISSING,
            UNDELIVERED,
            UNKNOWN
        }

        public enum DiskSize
        {
            GB_10 = 10000
        }

        public enum RoadCategory
        {
            ALL=0,
            PLANNED = 1,
            UNSORTED = 2,
            LOCAL = 3,
            COUNTY = 4,
            STATE = 5,
            SPEED = 6,
            HIGHWAY = 7
        }


        public enum RailroadCategory
        {
            ALL = 0,
            PLANNED = 1,
            LOCAL = 2,
            REGIONAL = 3,
            INTERNATIONAL = 4
        }

        public enum SpatialPlanDelivery
        {
            COMPLETE =1,
            INCOMPLETE_CD = 2,
            INCOMPLETE_ADDITIONAL_DOCUMENTS = 3,
            INCOMPLETE_PART = 4,
            NOT_DELIVERED = 5,
            UNKNOWN = 6
        }

        public enum LocalGovernment
        {
            ALL = 0,
        }

        public enum SpatialMeasure
        {
            ALL = 0
        }

        public enum SpatialPlanLevel
        {
            ALL = 0
        }

        public enum SpatialPlanners
        {
            ALL = 0
        }
    }
}
