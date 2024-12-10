import './input.css';

type InputProps = {
    label? : string;
    type: string;
    id: string;
    placeholder? : string;
    name: string;
    value? : string;
    onChange? : (e: React.ChangeEvent<HTMLInputElement>) => void;
    error? : string;
    accept? : string;
};

const Input = ({
    label,
    type,
    id,
    placeholder,
    name,
    value,
    onChange,
    error,
    accept,
}: InputProps) => {
    return (
        <div className="form-inner">
            {label && <label htmlFor={id}>{label}</label>}
            <input 
               type={type}
               placeholder={placeholder}
               id={id}
               name={name}
               value={value}
               onChange={onChange}
               accept={accept}
            />
            <span className="error-message">{error}</span>
        </div>
    )
};

export default Input;