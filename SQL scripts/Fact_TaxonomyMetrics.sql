CREATE TABLE [dbo].[Fact_TaxonomyMetrics](
     -- Mandatory Columns
     [SegmentRecordId] [bigint] NOT NULL,
     [SegmentId] [uniqueidentifier] NOT NULL,
     [Date] [smalldatetime] NOT NULL,
     [SiteNameId] [int] NOT NULL,
     [DimensionKeyId] [bigint] NOT NULL,
     [FilterId] [uniqueidentifier] NULL,
            -- Dimension specific metric columns
     [Visits] [int] NOT NULL,
     [EngagementValue] [int] NOT NULL
CONSTRAINT [PK_Fact_TaxonomyMetrics_1] PRIMARY KEY CLUSTERED 
     (
     [SegmentRecordId] ASC
     )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
     ) ON [PRIMARY]

