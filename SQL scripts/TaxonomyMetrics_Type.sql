CREATE TYPE [dbo].[TaxonomyMetrics_Type] AS TABLE(
     -- Mandatory Columns
     [SegmentRecordId] [bigint] NOT NULL,
     [SegmentId] [uniqueidentifier] NOT NULL,
     [Date] [smalldatetime] NOT NULL,
     [SiteNameId] [int] NOT NULL,
     [DimensionKeyId] [bigint] NOT NULL,
     [FilterId] [uniqueidentifier] NULL,

     -- Dimension specific metric columns
     [Visits] [int] NOT NULL,
     [EngagementValue] [int] NOT NULL,    
     PRIMARY KEY CLUSTERED 
     (
     [SegmentRecordId] ASC
     )WITH (IGNORE_DUP_KEY = OFF)
     )

