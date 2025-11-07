export class ApiService {
  constructor(baseUrl) {
    this.baseUrl = baseUrl;
  }
  async post(endpoint, data) {
    try {
      const response = await fetch(`${this.baseUrl}${endpoint}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error(`HTTP error: ${response.status}`);
      }

      const result = await response.json();
      return result;
    } 
    catch (error) {
      console.error("POST Error:", error);
      throw error;
    }
  }
}

