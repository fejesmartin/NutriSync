import * as React from 'react';
import Button from '@mui/joy/Button';
import SvgIcon from '@mui/joy/SvgIcon';
import { styled } from '@mui/joy';

const VisuallyHiddenInput = styled('input')`
  clip: rect(0 0 0 0);
  clip-path: inset(50%);
  height: 1px;
  overflow: hidden;
  position: absolute;
  bottom: 0;
  left: 0;
  white-space: nowrap;
  width: 1px;
`;

interface FileUploadProps {
  onImageChange: (imageUrl: string) => void;
}

const FileUpload: React.FC<FileUploadProps> = ({ onImageChange }) => {
  const inputRef = React.useRef<HTMLInputElement>(null);

  const handleClick = () => {
    if (inputRef.current) {
      inputRef.current.click();
    }
  };

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];

    if (file) {
      // Check if the file size exceeds the maximum allowed size (3MB)
      const maxSize = 3 * 1024 * 1024; // 3MB in bytes
      if (file.size > maxSize) {
        // Display an error message or handle the oversized file
        alert("Please upload an image under 3MB.");
        return; // Do not proceed with reading the file
      }
  
      const reader = new FileReader();
      reader.onloadend = () => {
        const imageUrl = reader.result as string;
        localStorage.setItem('profilePictureUrl', imageUrl); // Save image URL to local storage
        onImageChange(imageUrl); // Update state with selected image URL
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <>
      <Button
        component="label"
        role={undefined}
        tabIndex={-1}
        variant="outlined"
        color="neutral"
        startDecorator={
          <SvgIcon>
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              strokeWidth={1.5}
              stroke="currentColor"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M12 16.5V9.75m0 0l3 3m-3-3l-3 3M6.75 19.5a4.5 4.5 0 01-1.41-8.775 5.25 5.25 0 0110.233-2.33 3 3 0 013.758 3.848A3.752 3.752 0 0118 19.5H6.75z"
              />
            </svg>
          </SvgIcon>
        }
        onClick={handleClick}
      >
        Upload a file
      </Button>
      <VisuallyHiddenInput
        type="file"
        accept="image/*"
        ref={inputRef}
        onChange={handleFileChange}
      />
    </>
  );
};

export default FileUpload;