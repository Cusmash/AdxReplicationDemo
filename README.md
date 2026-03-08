# AdxReplicationDemo - Architecture roadmap
- The main goal is to practice a Request/Processor pattern where sql data should be saved into ADX/Kusto
- didn't create a UI layer, endpoints are validated by postman

File Structure
src/
  AdxReplicationDemo.Contracts
  AdxReplicationDemo.Data
  AdxReplicationDemo.Logic
  AdxReplicationDemo.Host

Requests
POST /data/get-service-audit-data
- Request
- Processor
- Extractor
- Reader
- SQL View
- JSON response

GET /odata/service-audit-data
- Endpoint
- Reader
- SQL View
- JSON response

SQL
DB 
- AdxTest

Tables
- dbo.Services
- dbo.ServiceAudits
- dbo.BackgroundJobExecutions

Views
- dbo.vw_ServiceAuditData
- dbo.vw_ServiceJobData
