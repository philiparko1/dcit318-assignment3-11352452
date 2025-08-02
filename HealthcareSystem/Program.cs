using HealthcareSystem;

var app = new HealthSystemApp();

// Initialize data
app.SeedData();
app.BuildPrescriptionMap();

// Display results
app.PrintAllPatients();

// Show prescriptions for patient 1 as example
app.PrintPrescriptionsForPatient(1);

/* Additional test cases we can try:
app.PrintPrescriptionsForPatient(2);
app.PrintPrescriptionsForPatient(99); // Non-existent patient
*/