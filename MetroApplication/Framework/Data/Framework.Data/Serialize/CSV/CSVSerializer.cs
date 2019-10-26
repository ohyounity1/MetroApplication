using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.VisualBasic.FileIO;

using Framework.Utility.Patterns;

namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// Serializer for CSV files, which implements interface <see cref="IInOutSerializer"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CSVSerializer<TContainer, TReadItem, TWriteItem> : InOutSerializer<TContainer> where TReadItem : new() where TContainer: new()
    {
        // Current headers
        private readonly IList<string> _headerLocations = new List<string>();

        #region Reading
        /// <summary>
        /// Read a specific field on the current line
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="data"></param>
        protected abstract void ReadField(string field, string value, TReadItem newItem);

        protected abstract void AddNewItem(TReadItem newItem);
        #endregion

        #region Writing
        /// <summary>
        /// Write out the header at the top of the file
        /// </summary>
        /// <param name="headers"></param>
        protected abstract void WriteHeader(IList<string> headers);

        /// <summary>
        /// Begin writing a new line
        /// </summary>
        /// <param name="data"></param>
        protected abstract TWriteItem WriteNewLine();

        protected abstract string WriteField(string header, TWriteItem currentItem);

        protected abstract bool EndOfData();
        #endregion

        /// <summary>
        /// <see cref="IInSerializer.Load(TextReader)"/>
        /// </summary>
        /// <param name="reader">The source of the data</param>
        /// <returns>true for success, false for failure</returns>
        public override bool Load(TextReader reader)
        {
            // Read out the csv file
            using var csvLoader = new TextFieldParser(reader)
            {
                // Configure the reader to use , as the delimiter
                TextFieldType = FieldType.Delimited
            };
            csvLoader.SetDelimiters(",");
            var headerLine = true;

            Data = new TContainer();
            // Read all lines
            while (!csvLoader.EndOfData)
            {
                // First line is the header
                var fields = csvLoader.ReadFields();
                if (headerLine)
                {
                    fields.ForEach((f) => _headerLocations.Add(f));
                    // Call subclass so they can know which column goes with which piece of data
                    //ConfigureHeader(fields);
                    headerLine = false;
                }
                else
                {
                    var itemIndex = 0;
                    var newItem = new TReadItem();

                    foreach (var lineData in fields)
                    {
                        // Validate the item index
                        if (itemIndex < _headerLocations.Count)
                        {
                            // Line up the column with the current position we are in
                            var currentHeader = _headerLocations[itemIndex];
                            // Now read all the data lines
                            ReadField(currentHeader, lineData, newItem);
                        }
                    }

                    AddNewItem(newItem);
                }
            }
            return true;
        }
        /// <summary>
        /// <see cref="IOutSerializer.Save(TextWriter)"/>
        /// </summary>
        /// <param name="writer">Where to store the CSV data</param>
        /// <returns>true for success, false for failure</returns>
        public override bool Save(TextWriter writer)
        {
            if (Data == null)
                throw new InvalidOperationException("Data property is not currently set to any data!");
            // Not implemented right now, not saving to CSV files
            _headerLocations.Clear();
            WriteHeader(_headerLocations);

            writer.WriteLine(string.Join(",",_headerLocations));

            while (!EndOfData())
            {
                var currentItem = WriteNewLine();
                var fields = new List<string>();
                foreach (var header in _headerLocations)
                {
                    var result = WriteField(header, currentItem);
                    fields.Add(result);
                }
                writer.WriteLine(string.Join(",", fields));
            }

            return true;
        }
        /// <summary>
        /// Data source
        /// </summary>
        public override TContainer Data
        {
            get;
            set;
        }
    }
}
