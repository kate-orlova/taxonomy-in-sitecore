CREATE PROCEDURE [dbo].[Add_TaxonomyMetrics_Tvp]
       @table [dbo].[TaxonomyMetrics_Type] READONLY
     AS
     BEGIN
       SET NOCOUNT ON;

       BEGIN TRY

         MERGE [Fact_TaxonomyMetrics] AS Target USING @table AS Source
         ON 
           Target.[SegmentRecordId] = Source.[SegmentRecordId]
         WHEN MATCHED THEN
           UPDATE SET 
             Target.[Visits] = (Target.[Visits] + Source.[Visits]),
             Target.[EngagementValue] = (Target.[EngagementValue] + Source.[EngagementValue])            
         WHEN NOT MATCHED THEN
           INSERT (
     [SegmentRecordId],
     [SegmentId],
     [Date],
     [SiteNameId],
     [DimensionKeyId],
     [FilterId],
     [Visits],
     [EngagementValue]
           )
           VALUES (
     Source.[SegmentRecordId],
     Source.[SegmentId],
     Source.[Date],
     Source.[SiteNameId],
     Source.[DimensionKeyId],
     Source.[FilterId],
     Source.[Visits],
     Source.[EngagementValue]
     );

       END TRY
       BEGIN CATCH

         DECLARE @error_number INTEGER = ERROR_NUMBER();
         DECLARE @error_severity INTEGER = ERROR_SEVERITY();
         DECLARE @error_state INTEGER = ERROR_STATE();
         DECLARE @error_message NVARCHAR(4000) = ERROR_MESSAGE();
         DECLARE @error_procedure SYSNAME = ERROR_PROCEDURE();
         DECLARE @error_line INTEGER = ERROR_LINE();

         RAISERROR( N'T-SQL ERROR %d, SEVERITY %d, STATE %d, PROCEDURE %s, LINE %d, MESSAGE: %s', @error_severity, 1, @error_number, @error_severity, @error_state, @error_procedure, @error_line, @error_message ) WITH NOWAIT;
       END CATCH;
     END

