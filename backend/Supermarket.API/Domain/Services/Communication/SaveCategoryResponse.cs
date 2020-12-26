using System;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }
        
        private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response
        /// </summary>
        /// <param name="category">Saved category</param>
        /// <returns>Response</returns>
        public SaveCategoryResponse(Category category) : this(true, String.Empty, category)
        {
            
        }

        /// <summary>
        /// Creates an error response
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Response</returns>
        public SaveCategoryResponse(string message) : this(false, message, null)
        {
            
        }
        
        
    }
}